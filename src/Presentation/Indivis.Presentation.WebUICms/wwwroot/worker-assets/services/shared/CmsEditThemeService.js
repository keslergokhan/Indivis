import { WidgetFormIframe,HelperFunction } from '../helpers/HelperFunctions.js';

export class CmsEditThemeService {


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
                this.PageZones.push(new PageZone(x));
            }
                
        })
    }

    /**
     * Yüklenen zone nesnelerini çalıştır.
     */
    pageZoneExecute = () => {
        this.PageZones.forEach(pageZone => {
            pageZone.execute();
        })
    }

    /**
     * Widget eklemek için element sürüklendiğine zone yapılarını göster
     */
    pageZoneDragStartStyle = () => {
        this.PageZones.forEach(x => {
            x.pageZoneDragStartStyle()
        });
    }

    /**
     * Widget eklemek için element sürükleme bırakıldığında zone yapılarını gizle
     */
    pageZoneDragEndStyle = () => {
        this.PageZones.forEach(x => {
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


    getZoneId = () => {
        return this.Zone.getAttribute("data-zone-id");
    }
    getZoneKey = () => {
        return this.Zone.getAttribute("data-zone-key");
    }


    /**
     * Zone yapısı içindeki widget nesnelerini oluştur ve çalıştır.
     */
    createPageZoneWidgets = () => {

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

            //widget formiframe
            WidgetFormIframe.show(dataTransferJson.widgetName, dataTransferJson.widgetId, dataTransferJson.widgetTemplateId);

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


