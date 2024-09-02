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
    }

    /**
     * Zone yeni widget ekleme button HTML kodu
     * @param {any} attrKey button özellik adı
     * @returns
     */
    getZoneAddButtonHTML = (attrKey) => {
        return `<button onload="console.log('merhaba dünya')" class="cms-btn cms-btn-success" ${attrKey}="${this.getZoneId()}">Yeni Tasarım Ekle</button>`;
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

    zoneButtonClickEvent = async () => {

        const button = await this.zoneSetButtonHanlderAsync();

        button.addEventListener('click', () => {
            console.log(this.getZoneId());
        })
        
    }

    execute = () => {
        this.zoneButtonClickEvent();
    }
}