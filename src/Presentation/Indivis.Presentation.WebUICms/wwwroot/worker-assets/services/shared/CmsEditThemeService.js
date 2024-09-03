import { HelperFunction } from "../helpers/HelperFunctions.js";

export class CmsEditThemeService {
    /**
     * Sayfa içerisindeki zone yapılarına yeni widget ekleme buttonu
     * @param {Event} e
     */
    createObjectZone = (e) => {
        /** @type {NodeListOf}  */
        const zoneList = document.querySelectorAll(".zone-section");

        zoneList.forEach((x) => 
        {
            if (x) {
                new PageZone(x).execute();
            }
                
        })
        

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

    /**
     * Zone yeni widget ekleme button HTML kodu
     * @param {any} attrKey button özellik adı
     * @returns
     */
    getZoneAddButtonHTML = (attrKey) => {
        return `<button class="cms-btn cms-btn-success" ${attrKey}="${this.getZoneId()}">Yeni Tasarım Ekle </button>`;
    }

    getZoneId = () => {
        return this.Zone.getAttribute("data-zone-id");
    }
    getZoneKey = () => {
        return this.Zone.getAttribute("data-zone-key");
    }

    /**
     * Zone alanına widget ekleme buttonu oluşturur
     * @returns {Element}
     */
    zoneSetButtonHanlderAsync = async () => {
        const key = "zone-add-widget-btn";
        this.Zone.querySelector(".zone-buttons").insertAdjacentHTML('afterbegin', this.getZoneAddButtonHTML(key));
        return this.Zone.querySelector(`[${key}="${this.getZoneId()}"]`)
    }

    /**
     * Mevcut Zone alanına yeni widget ekleme buttonu click event
     */
    zoneButtonClickEvent = async () => {

        const button = await this.zoneSetButtonHanlderAsync();

        button.addEventListener('click', () => {
            console.log(this.getZoneId());
        })
    }

    /**
     * Zone içindeki yüklenmesi gereken widget yapıları
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

    execute = () => {
        this.zoneButtonClickEvent();
        this.createPageZoneWidgets();
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
     * Widget tasarımı alınacak url adresi
     * @param {string} id
     * @returns {string}
     */
    getWidgetTemplateApiUrl = (id) => {
        const path = window.location.pathname.replace("/cms-page-edit", "/widget-template");
        return `${path}?pageWidgetId=${id}`;
    }

    /**
     * 
     * @param {string} html
     */
    setWidgetHtmlTemplate = (html) => {
        HelperFunction.stopSpinner(this.Widget);
        this.Widget.innerHTML = html;
    }
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
            alert("Beklenmedik bir hata oluştu !");
        })
    }

    execute = async () => {
        await this.getWidgetTemplateAsync();
    }
}