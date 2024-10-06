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
    static addPageZoneNewWidget = (newWidgetData) => {

        const pageZoneId = newWidgetData.pageWidget.pageZoneId;
        const zoneWidgetId = newWidgetData.pageWidget.id;
        const grid = newWidgetData.pageWidget.pageWidgetSetting.Grid;
        const widgetId = newWidgetData.pageWidget.WidgetId;
        const widgetTemplateId = newWidgetData.pageWidget.pageWidgetSetting.WidgetTemplateId;


        /** @type {PageZone} */
        const pageZoneResult = CmsEditThemeService.PageZones.find(x => x.getZoneId() == pageZoneId);

        if (pageZoneResult) {
            /*
                db yeni eklenen kayıt için html içine boş bir Widget tasarımı eklendi ve ilgili zone restart edildi
                bu şekilde tasarımda bilgiler eklenmiş olan widget için tasarım çekildi
            */
            pageZoneResult.addNewWidget(zoneWidgetId, grid, widgetId, widgetTemplateId);
            pageZoneResult.execute();
        }
    }


    /**
     * Mevcut zone yeniden başlat.
     * @param {guid} pageZoneId
     */
    static pageZoneRestart = (pageZoneId) => {

        /** @type {PageZone} */
        const pageZoneResult = CmsEditThemeService.PageZones.find(x => x.getZoneId() == pageZoneId);

        if (pageZoneResult) {
            pageZone.execute();
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
                this.Widgets.push(new ZoneWidget(x,this));
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
    addNewWidget = (zoneWidgetId,grid,widgetId,widgetTemplateId) => {
        this.getZoneWidgetContainer().insertAdjacentHTML('beforeend', ZoneWidget.getWidgetHTMLElement(grid, zoneWidgetId, widgetId, widgetTemplateId));
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

            const widgetFormIframeShowData = new WidgetFormIframeShowData(
                this.getZoneId(),
                dataTransferJson.widgetId,
                dataTransferJson.widgetName,
                dataTransferJson.widgetTemplateId,
                this.GetZonePageId(),
            );

            widgetFormIframeShowData.setIsUpdateIframe(false);
            //widget formiframe
            WidgetFormIframe.show(widgetFormIframeShowData);

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
    }
}


class ZoneWidget {

    /**
     * @param {Element} widget
     * @param {Element} pageZone
     */
    constructor(widget, pageZone) {

        /**
         * @type {Element}
         */
        this.Widget = widget;

        /**
         * @type {Element}
         */
        this.PageZone = pageZone;
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


    /**
     * PageWidgetId değerini getir
     * @returns {string}
     */
    getPageWidgetId = () => {
        return this.Widget.getAttribute("data-page-widget-id");
    }

    /**
     * WidgetTemplateId değerini getir.
     * @returns
     */
    getWidgetTemplateId = () => {
        return this.Widget.getAttribute("data-widget-templage-id");
    }

    /**
     * Widget değerini getir
     * @returns {string}
     */
    getWidgetId = () => {
        return this.Widget.getAttribute("data-widget-id");
    }

    /**
     * Widget güncelleme buttonu
     * @returns {ParentNode}
     */
    getWidgetUpdateBtn = () => {
        return this.Widget.querySelector(".js-update-widget");
    }

    /**
     * Widget  Sil Buttonu
     * @returns {ParentNode}
     */
    getWidgetRemoveBtn = () => {
        return this.Widget.querySelector(".js-remove-widget");
    }

    /**
     * Widget yukarı taşı buttonu
     * @returns
     */
    getWidgetUpBtn = () => {
        return this.Widget.querySelector(".js-up-widget");
    }

    /**
     * Widget aşağı taşı buttonu
     * @returns
     */
    getWidgetDownBtn = () => {
        return this.Widget.querySelector(".js-down-widget");
    }

    widgetUpdateBtnHandlerAsync = async () => {

        this.getWidgetUpdateBtn().addEventListener('click', async () => {

            const widgetFromIframeData = new WidgetFormIframeShowData(
                this.PageZone.getZoneId(),
                this.getWidgetId(),
                "Güncelle",
                this.getWidgetTemplateId(),
                this.PageZone.GetZonePageId(),
                
            );

            widgetFromIframeData.setPageWidgetId(this.getPageWidgetId());
            widgetFromIframeData.setIsUpdateIframe(true);

            WidgetFormIframe.show(widgetFromIframeData);
            WidgetFormIframe.updateBtn();
        });
    }


    

    /**
     * widget sil api isteği
     * @returns {string}
     */
    removePageWidgetFetchAsync = async () => {

        const settings = {
            method: "POST",
            body: JSON.stringify({ pageWidgetId: this.getPageWidgetId() }),
            headers: {
                'Content-Type': 'application/json',
            }
        }

        let jsonData;
        await fetch('/api/widgetFormApi/remove-widget', settings).then(x => {
            jsonData = x.json();
        });

        return jsonData;
    }

    /**
     * Widget sil button süreçleri
     */
    widgetRemoveBtnHandlerAsync = async () => {

        this.getWidgetRemoveBtn().addEventListener('click', () => {

            Swal.fire({
                title: "Sil !",
                text: "Seçilen tasarımın silmek istediğinizden emin misiniz !",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Evet Sil!",
                cancelButtonText:"Hayır"
            }).then(async (result) => {
                if (result.isConfirmed) {

                    const removeResult = await this.removePageWidgetFetchAsync();
                    if (removeResult.isSuccess) {
                        CmsAlert.success("İşlem Başarılı", "Tasarım kaldırıldı !");
                        this.PageZone.execute();
                        this.Widget.remove();
                    } else {
                        CmsAlert.error("Hata !", "Beklenmedik teknik bir prob")
                    }

                }
            });
        });
        
    }

    /**
     * Boş widget şablonu
     * @param {string} grid
     * @param {string} pageWidgetId
     * @returns {string}
     */
    static getWidgetHTMLElement = (grid, pageWidgetId,widgetId,widgetTemplateId) => {
        return `
            <div class="${grid} empty-widget cms-spinner-border" data-widet-template-id="${widgetTemplateId}" data-widget-id="${widgetId}" data-page-widget-id="${pageWidgetId}">
            
            </div>
        `;
    }

    upWidgetBtnHandlerAsync = async () => {
        this.getWidgetUpBtn().addEventListener('click', async (e) => {
            e.preventDefault();

            const id = this.getWidgetUpBtn().getAttribute("data-page-widget-setting-id");

            await fetch('/api/widgetFormApi/up-widget', {
                method: "POST",
                body: JSON.stringify(id),
                headers: {
                    'Content-Type': 'application/json',
                }
            })
            .then(res => res.json())
            .then(json => {
                if (json.isSuccess) {
                    this.PageZone.execute();
                }
            })
        })
    }

    downWidgetBtnHandlerAsync = async () => {
        this.getWidgetDownBtn().addEventListener('click', async (e) => {
            e.preventDefault();

            const id = this.getWidgetUpBtn().getAttribute("data-page-widget-setting-id");

            await fetch('/api/widgetFormApi/down-widget', {
                method: "POST",
                body: JSON.stringify(id),
                headers: {
                    'Content-Type': 'application/json',
                }
            })
            .then(res => res.json())
            .then(json => {
                if (json.isSuccess) {
                    this.PageZone.execute();
                }
            })
        })
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
        await this.widgetRemoveBtnHandlerAsync();
        await this.widgetUpdateBtnHandlerAsync();
        await this.upWidgetBtnHandlerAsync();
        await this.downWidgetBtnHandlerAsync();
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
        this.UpdateWidgetUrl = '/api/widgetFormApi/update-widget';
    }

    /**
     * Widget ayarlar form süreçleri
     * @returns {object}
     */
    widgetFormSettingsHandler = () => {
        if (WidgetFormIframe.WidgetFormIframaData == null) {
            console.error("WidgetFromIframe drop json ulaşılamadı");
            alert("Teknik bir problem yaşandı lütfen daha sonra tekrar deneyin ! widgetFormSubmitEventHandler");
        }
        const formData = new FormData(WidgetFormIframe.SettingsForm);

        formData.append("WidgetTemplateId", WidgetFormIframe.WidgetFormIframaData.WidgetTemplateId);
        formData.append("PageId", WidgetFormIframe.WidgetFormIframaData.PageId);
        formData.append("PageZoneId", WidgetFormIframe.WidgetFormIframaData.PageZoneId);
        formData.append("WidgetId", WidgetFormIframe.WidgetFormIframaData.WidgetId);

        if (WidgetFormIframe.WidgetFormIframaData.IsUpdateIframe) {
            //güncellenecek olan PageWidgetId değerini form attr al
            formData.append("PageWidgetId", WidgetFormIframe.SettingsForm.getAttribute("data-page-widget-id"));
        }

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
                WidgetFormIframe.hide();
                CmsAlert.successTopEnd(`${widgetFormRequest.WidgetSetting.Name}, başarıyla eklendi`);

                CmsEditThemeService.addPageZoneNewWidget(json.data);

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


    /**
     * Yeni bir widget ekle
     * @param {WidgetFormRequest} widgetFormRequest
     */
    updateWidgetAsync = async (widgetFormRequest) => {
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

        await fetch(this.UpdateWidgetUrl, settings).then(res => res.json()).then(json => {
            if (json.isSuccess) {
                WidgetFormIframe.hide();
                CmsAlert.successTopEnd(`${widgetFormRequest.WidgetSetting.Name}, başarıyla eklendi`);

                CmsEditThemeService.addPageZoneNewWidget(json.data);

            } else {
                CmsAlert.error("Hata", "Beklenmedik teknik bir problem yaşandı lütfen daha sonra tekrar deneyiniz !");
                console.error("Widget güncelleme sürecinde teknik bir problem yaşandı !");
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
     * Yeni widget ekleme
     */
    widgetFormSubmitEventHandler = () => {
        if (WidgetFormIframe.IframeContent) {
            WidgetFormIframe.IframeContent.querySelector(`.js-widget-form-iframe-submit`).addEventListener('click', async (e) => {
                e.preventDefault();

                const setting = this.widgetFormSettingsHandler();
                const data = this.widgetFormDataHandler();

                await this.addWidgetAsync(new WidgetFormRequest(setting, data));

            });
        }
    }

    /**
     * Mevcut widget güncelle
     */
    widgetUpdateFormSubmitEventHandler = () => {
        if (WidgetFormIframe.IframeContent) {
            WidgetFormIframe.IframeContent.querySelector(`.js-widget-form-iframe-update-submit`).addEventListener('click', async (e) => {
                e.preventDefault();

                const setting = this.widgetFormSettingsHandler();
                const data = this.widgetFormDataHandler();

                await this.updateWidgetAsync(new WidgetFormRequest(setting, data));
            });
        }
    }


    execute = () => {
        this.widgetFormSubmitEventHandler();
        this.widgetUpdateFormSubmitEventHandler();
    }
}

export class WidgetFormIframeShowData {
    /**
     * 
     * @param {any} pageZoneId
     * @param {any} widgetId
     * @param {any} widgetName
     * @param {any} widgetTemplateId
     * @param {any} pageId
     */
    constructor(pageZoneId,widgetId,widgetName,widgetTemplateId,pageId) {
        this.PageZoneId = pageZoneId;
        this.PageId = pageId;
        this.WidgetId = widgetId;
        this.WidgetName = widgetName;
        this.WidgetTemplateId = widgetTemplateId;
        this.PageWidgetId = null;
        this.IsUpdateIframe = false;
    }

    setPageWidgetId = (pageWidgetId) => {
        this.PageWidgetId = pageWidgetId;
    }

    setIsUpdateIframe = (state) => {
        this.IsUpdateIframe = state;
    }
}

export class WidgetFormIframe {

    static isExecute = false;
    static IframeContent = document.querySelector(".js-widget-form-iframe");
    /**  Widget Settins Form @type {Element}*/
    static SettingsForm = null;
    /**  Widget Dynamic Input Form @type {Element} */
    static DataForm = null;

    /** @type {WidgetFormIframeShowData} */
    static WidgetFormIframaData = null;
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

    /**
     * WidgetFormUpdate yapısını getiren iframe src düzenle
     * @param {string} pageWidgetId
     * @returns
     */
    static setUpdateIframeSrc = (pageWidgetId) => {
        return this.IframeContent.querySelector("iframe").src = `/api/widgetformapi/getUpdateform/${pageWidgetId}`;
    }


    static setIframeSrcEmpty = () => {
        return this.IframeContent.querySelector("iframe").src = ``;
    }


    static updateBtn = () => {
        this.IframeContent.querySelector(".js-widget-form-iframe-update-submit").style.display = "inline-block";
        this.IframeContent.querySelector(".js-widget-form-iframe-submit").style.display = "none";
    }

    static addBtn = () => {
        this.IframeContent.querySelector(".js-widget-form-iframe-update-submit").style.display = "none";
        this.IframeContent.querySelector(".js-widget-form-iframe-submit").style.display = "inline-block";
    }

    /**
     * 
     * @param {WidgetFormIframeShowData} WidgetFormIframeData
     */
    static show = (WidgetFormIframeData) => {

        this.addBtn();
        this.WidgetFormIframaData = WidgetFormIframeData;

        this.IframeContent.classList.add("widget-form-iframe--show");
        if (WidgetFormIframeData.WidgetName) {
            this.IframeContent.querySelector(".widget-form-iframe__header-title").innerHTML = WidgetFormIframeData.WidgetName;
        }
        if (!WidgetFormIframeData.WidgetId || !WidgetFormIframeData.WidgetTemplateId) {
            alert("Teknik bir problem yaşandı lütfen daha sonra tekrar deneyiniz !");
            console.error("Sürüklenen widget settings değerlerine ulaşılamadı !");
        }


        if (WidgetFormIframeData.IsUpdateIframe) {
            this.setUpdateIframeSrc(WidgetFormIframeData.PageWidgetId);
        } else {
            this.setIframeSrc(WidgetFormIframeData.WidgetId, WidgetFormIframeData.WidgetTemplateId);
        }

        document.body.style.overflow = "hidden";
    }


    /**
     * WidgetFormIFrame tasarımını hizle
     */
    static hide = () => {
        this.IframeContent.classList.remove("widget-form-iframe--show");
        document.body.style.overflow = "auto";
        this.WidgetFormIframaData = null;
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