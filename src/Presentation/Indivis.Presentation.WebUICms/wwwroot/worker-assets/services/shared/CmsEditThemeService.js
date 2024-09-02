import { HelperFunction } from "../helpers/HelperFunctions.js";

export class CmsEditThemeService {
    /**
     * Sayfa içerisindeki zone yapılarına yeni widget ekleme buttonu
     * @param {Event} e
     */
    createZone = (e) => {
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
     * Zone yeni widget ekleme buttonu click event
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

        console.log(zoneWidgetList.length);
        if (zoneWidgetList.length > 0) {
            zoneWidgetList.forEach(x => {
                this.Widgets.push(new ZoneWidget(x));
            });
        }
        
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


    getWidgetTemplateAsync = async () => {

    }

    execute = () => {

    }
}