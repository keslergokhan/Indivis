import { HelperFunction,CmsAlert } from '../helpers/HelperFunctions.js';

export class CmsEditThemeService {

    static PageZones = [];
    constructor() {
        /** @type {Array<PageZone>} */
        this.PageZones = [];
    }

    /**
     * Zone nesnelerini oluştur
     * @param {Event} e
     */
    createObjectZone = (e) => {
        /** @type {NodeListOf}  */
        const zoneList = document.querySelectorAll(".zone-section");

        zoneList.forEach((x) => 
        {
            if (x) {
                CmsEditThemeService.PageZones.push(new PageZone(x));
            }
                
        })
    }

    /**
     * PageZoneId değerine sahip zone alanına yeni widget ekle
     * @param {string} pageZoneId
     * @param {string} zoneWidgetId
     * @param {string} grid
     */
    static addPageZoneNewWidget = (pageZoneId, zoneWidgetId, grid) => {

        /** @type {PageZone} */
        const pageZoneResult = CmsEditThemeService.PageZones.find(x => x.getZoneId() == pageZoneId);

        if (pageZoneResult) {
            pageZoneResult.addNewWidget(zoneWidgetId,grid);
            pageZoneResult.execute();
        }
    }

    

    /**
     * Yüklenen zone nesnelerini çalıştır.
     */
    pageZoneExecute = () => {
        CmsEditThemeService.PageZones.forEach(pageZone => {
            pageZone.execute();
        })
    }

    /**
     * Widget eklemek için element sürüklendiğine zone yapılarını göster
     */
    pageZoneDragStartStyle = () => {
        CmsEditThemeService.PageZones.forEach(x => {
            x.pageZoneDragStartStyle()
        });
    }

    /**
     * Widget eklemek için element sürükleme bırakıldığında zone yapılarını gizle
     */
    pageZoneDragEndStyle = () => {
        CmsEditThemeService.PageZones.forEach(x => {
            x.pageZoneDragEndStyle()
        });
    }

}




class PageZone {

    /**
     * 
     * @param {Element} zone
     */
    constructor(zone) {
        this.Zone = zone;
        /** @type {Array<ZoneWidget>} */
        this.Widgets = [];
    }

    GetZonePageId = () => {
        return this.Zone.getAttribute("data-zone-page-id");
    }
    getZoneId = () => {
        return this.Zone.getAttribute("data-zone-id");
    }
    getZoneKey = () => {
        return this.Zone.getAttribute("data-zone-key");
    }
    getZoneWidgetContainer = () => {
        return this.Zone.querySelector(".zone-widgets-container");
    }


    /**
     * Zone yapısı içindeki widget nesnelerini oluştur ve çalıştır.
     */
    createPageZoneWidgets = () => {
        this.Widgets = [];
        const zoneWidgetList = this.Zone.querySelectorAll(`[data-page-widget-id]`);

        if (zoneWidgetList.length > 0) {
            zoneWidgetList.forEach(x => {
                this.Widgets.push(new ZoneWidget(x));
            });
        }

        this.Widgets.forEach(x => {
            x.execute();
        });
    }

    /**
     * Zone içine yeni bir widget elementi ekle
     * @param {string} zoneWidgetId
     * @param {string} grid
     */
    addNewWidget = (zoneWidgetId,grid) => {
        this.getZoneWidgetContainer().insertAdjacentHTML('beforeend', ZoneWidget.getWidgetHTMLElement(grid, zoneWidgetId));
    }

    pageZoneDragStartStyle = () => {
        this.pageZoneDragEndStyle();
        this.Zone.querySelector(".zone-widgets-container").classList.add("zone-widgets-container--active");
    }

    pageZoneDragEndStyle = () => {
        this.Zone.querySelector(".zone-widgets-container").classList.remove("zone-widgets-container--active");
        this.Zone.querySelector(".zone-widgets-container").classList.remove("zone-widgets-container--dragover");
    }

    /**
     * Sürüklenen bir öğe hedef öğenin üzerine geldiğinde
     */
    pageZoneDragoverHandler = () => {
        this.Zone.addEventListener('dragover', (event) => {
            event.preventDefault();
            this.Zone.querySelector(".zone-widgets-container").classList.add("zone-widgets-container--dragover");
        });
    }

    /**
     * Sürüklenen öğe hedef öğeye bırakıldığında tetiklenir.
     */
    pageZoneDropHandler = () => {
        this.Zone.addEventListener('drop', (event) => {
            event.preventDefault();
            this.pageZoneDragEndStyle();

            // Sürüklenen widget elementin transferedilen verileri
            const dataTransferJson = JSON.parse(event.dataTransfer.getData('text/plain')); 
            const currentZoneData = {
                pageZoneId : this.getZoneId(),
                pageId : this.GetZonePageId(),
            }

            //widget formiframe
            WidgetFormIframe.show({ ...dataTransferJson, ...currentZoneData });

        });
    }

    /**
     * Sürüklenen öğe hedef öğeden ayrıldığında
     */
    pageZoneDragleaveHandler = () => {
        this.Zone.addEventListener('dragleave', (event) => {
            event.preventDefault();
            this.pageZoneDragEndStyle();
            this.pageZoneDragStartStyle();
        });
    }

    execute = () => {
        this.createPageZoneWidgets();
        this.pageZoneDragoverHandler();
        this.pageZoneDropHandler();
        this.pageZoneDragleaveHandler();
        console.log("calisti");
        console.log(this);
    }
}


class ZoneWidget {

    /**
     * 
     * @param {Element} widget
     */
    constructor(widget) {
        this.Widget = widget;
    }

    /**
     * 
     * @returns {string}
     */
    getPageWidgetId = () => {
        return this.Widget.getAttribute("data-page-widget-id");
    }

    /**
     * Widget tasarım api
     * @param {string} id
     * @returns {string}
     */
    getWidgetTemplateApiUrl = (id) => {
        const path = window.location.pathname.replace("/cms-page-edit", "/widget-template");
        return `${path}?pageWidgetId=${id}`;
    }

    static getWidgetHTMLElement = (grid, pageWidgetId) => {
        return `
            <div class="${grid} empty-widget cms-spinner-border" data-page-widget-id="${pageWidgetId}">
            yeni element eklendi
            </div>
        `;
    }

    /**
     * Widget tasarımım gelene kadar Spinner çıkart
     * @param {string} html
     */
    setWidgetHtmlTemplate = (html) => {
        HelperFunction.stopSpinner(this.Widget);
        this.Widget.innerHTML = "";
        this.Widget.innerHTML = html;
    }

    /**
     * Widget tasarımını getir
     */
    getWidgetTemplateAsync = async () => {
        const url = this.getWidgetTemplateApiUrl(this.getPageWidgetId());

        await fetch(url).then(res => {
            if (res.status !== 200) {
                throw new Error("Beklenmedik bir hata oluştu");
            }

            return res.text();
        }).then(html => {
            this.setWidgetHtmlTemplate(html);
        }).catch(error => {
            alert("Beklenmedik bir hata oluştu ! getWidgetTemplateAsync");
        })
    }

    execute = async () => {
        await this.getWidgetTemplateAsync();
    }
}


class WidgetFormRequest {
    constructor(widgetSetting, widgetData) {
        this.WidgetSetting = widgetSetting;
        this.WidgetData = widgetData;
    }
}

/**
 * Eklenmek istenen widget form yapısını oluşturan ve yöneten sınıf
 */
class WidgetForms {

    constructor() {
        this.AddWidgetUrl = "/api/WidgetFormApi/add-widget";
    }

    /**
     * Widget ayarlar form süreçleri
     * @returns {object}
     */
    widgetFormSettingsHandler = () => {
        if (WidgetFormIframe.DropDataTransferData == null) {
            console.error("WidgetFromIframe drop json ulaşılamadı");
            alert("Teknik bir problem yaşandı lütfen daha sonra tekrar deneyin ! widgetFormSubmitEventHandler");
        }
        const formData = new FormData(WidgetFormIframe.SettingsForm);

        formData.append("widgetTemplateId", WidgetFormIframe.DropDataTransferData.widgetTemplateId);
        formData.append("pageId", WidgetFormIframe.DropDataTransferData.pageId);
        formData.append("pageZoneId", WidgetFormIframe.DropDataTransferData.pageZoneId);
        formData.append("widgetId", WidgetFormIframe.DropDataTransferData.widgetId);
        return HelperFunction.formDataToJsonObject(formData);
    }

    /**
     * Dinamik widget form süreçleri
     * * @returns {object}
     */
    widgetFormDataHandler = () => {

        const formData = new FormData(WidgetFormIframe.DataForm);
        return HelperFunction.formDataToJsonObject(formData);
    }

    /**
     * Yeni bir widget ekle
     * @param {WidgetFormRequest} widgetFormRequest
     */
    addWidgetAsync = async (widgetFormRequest) => {


        if (widgetFormRequest.WidgetSetting.IsShow == "1") {
            widgetFormRequest.WidgetSetting.IsShow = true;
        } else {
            widgetFormRequest.WidgetSetting.IsShow = false;
        }

        const settings = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(widgetFormRequest)
        };

        await fetch(this.AddWidgetUrl, settings).then(res => res.json()).then(json => {
            if (json.isSuccess) {
                console.log(json);
                WidgetFormIframe.hide();
                CmsAlert.successTopEnd(`${widgetFormRequest.WidgetSetting.Name}, başarıyla eklendi`);

                CmsEditThemeService.addPageZoneNewWidget(json.data.pageWidget.pageZoneId, json.data.pageWidget.id, json.data.pageWidget.pageWidgetSetting);
            } else {
                CmsAlert.error("Hata", "Beklenmedik teknik bir problem yaşandı lütfen daha sonra tekrar deneyiniz !");
                console.error("Widget ekleme sürecinde teknik bir problem yaşandı !");
                console.error(json);
            }
            WidgetFormIframe.hide();
        }).catch(x => {
            alert("Beklenmedik bir problem yaşandı addWidgetAsync");
            console.error(x);
        })
    }



    widgetFormDataResetButtonHandler = () => {
        WidgetFormIframe.IframeContent.querySelector(`[type="reset"]`).addEventListener('click', (e) => {
            e.preventDefault();
            WidgetFormIframe.IframeContent.hide();
        });
    }

    /**
     * Widget iframe dinamik form submit event
     * Yeni widget ekleme
     */
    widgetFormSubmitEventHandler = () => {
        if (WidgetFormIframe.IframeContent) {
            WidgetFormIframe.IframeContent.querySelector(`[type="submit"]`).addEventListener('click', async (e) => {
                e.preventDefault();

                const setting = this.widgetFormSettingsHandler();
                const data = this.widgetFormDataHandler();

                await this.addWidgetAsync(new WidgetFormRequest(setting, data));

            });
        }

    }


    execute = () => {
        this.widgetFormSubmitEventHandler();
    }
}


export class WidgetFormIframe {

    static isExecute = false;
    static IframeContent = document.querySelector(".js-widget-form-iframe");
    static SettingsForm = null;
    static DataForm = null;
    static DropDataTransferData = null;
    static WidgetForms = null;
    static IframeFormsSumitHandlerCallBack = null;

    static getIframe = () => {
        return this.IframeContent.querySelector("iframe");
    }


    static closeButtonEvent = () => {
        if (this.IframeContent) {
            this.IframeContent.querySelector(".js-widget-form-iframe-close").addEventListener('click', () => {
                this.hide();
            });
        }
    }

    /**
     * IFrame içeriği yüklendiğinde çalıştırılacak işler
     */
    static IframeLoadHandler = () => {

        this.getIframe().addEventListener('load', () => {
            this.SettingsForm = this.getIframe().contentDocument.querySelector(".js-widget-form-settings");
            this.DataForm = this.getIframe().contentDocument.querySelector(".js-widget-form-data");

            if (typeof this.IframeFormsSumitHandlerCallBack === 'function') {

                this.IframeFormsSumitHandlerCallBack();
            }
        });
    }

    /**
     * WidgetForm yapısını getiren iframe src düzenle
     * @param {string} widgetId
     * @param {string} widgetTemplateId
     * @returns
     */
    static setIframeSrc = (widgetId, widgetTemplateId) => {
        return this.IframeContent.querySelector("iframe").src = `/api/widgetformapi/getform/${widgetId}/${widgetTemplateId}`;
    }

    static setIframeSrcEmpty = () => {
        return this.IframeContent.querySelector("iframe").src = ``;
    }



    /**
     * WidgetFormIframe tasarımını göster
     * @param {string} title
     * @param {string} widgetId
     * @param {string} widgetTemplateId
     */
    static show = (dropDataTransferData) => {

        const { widgetName, widgetId, widgetTemplateId } = dropDataTransferData;
        this.DropDataTransferData = dropDataTransferData;

        this.IframeContent.classList.add("widget-form-iframe--show");
        if (widgetName) {
            this.IframeContent.querySelector(".widget-form-iframe__header-title").innerHTML = widgetName;
        }
        if (!widgetId || !widgetTemplateId) {
            alert("Teknik bir problem yaşandı lütfen daha sonra tekrar deneyiniz !");
            console.error("Sürüklenen widget settings değerlerine ulaşılamadı !");
        }

        this.setIframeSrc(widgetId, widgetTemplateId);

        document.body.style.overflow = "hidden";
    }


    /**
     * WidgetFormIFrame tasarımını hizle
     */
    static hide = () => {
        this.IframeContent.classList.remove("widget-form-iframe--show");
        document.body.style.overflow = "auto";
        this.DropDataTransferData = null;
    }

    static execute() {
        if (this.WidgetForms === null) {
            this.WidgetForms = new WidgetForms();
            this.WidgetForms.execute();
        }
        this.closeButtonEvent();
        this.IframeLoadHandler();
    }
}

if (WidgetFormIframe.IframeContent) {
    WidgetFormIframe.execute();
}