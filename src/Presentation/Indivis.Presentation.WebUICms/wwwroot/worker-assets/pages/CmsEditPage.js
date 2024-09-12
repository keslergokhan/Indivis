import { CmsEditThemeService } from '../services/shared/CmsEditThemeService.js'

export class CmsEditPage {

    constructor() {
        /**
         * @type {CmsEditThemeService}
         */
        this._CmsEditThemeService = new CmsEditThemeService();
    }

    /**
     * Zone nesnelerini oluştur
     */
    createObjectZone = () => {
        window.addEventListener('load', (e) => {
            this._CmsEditThemeService.createObjectZone(e);
            this._CmsEditThemeService.pageZoneExecute();
        });
    }

    /**
     * Mobil menu toggle
     */
    topMenuButtonHandler = () => {
        const button = document.querySelector(".js-top-menu-button");
        button.addEventListener('click', function (e) {
            const menu = document.querySelector(".cms-editpage-top__menu__group");
            window.HelperFunction.toggleClass(menu, "cms-editpage-top__menu__group--toggle");
        })
    }

    /**
     * Yeni widget ekleme alanı aç/kapa toggle
     */
    widgetsButtonHandler = () => {
        const button = document.querySelector(".js-cms-editpage-widget-button");

        button.addEventListener('click', function (e) {
            const btn = document.querySelector(".cms-editpage-widget");
            window.HelperFunction.toggleClass(btn, "cms-editpage-widget--toggle");
        });
    }

    /**
     * Widget elementini tutup sürüklemeye başladığında
     */
    widgetsDraggableHandler = () => {
        /** @type {NodeListOf<Element>} */
        const widgetDraggableItem = document.querySelectorAll(".js-widget-item-draggable");

        for (const item of widgetDraggableItem) {

            item.addEventListener('dragstart', (event) => {
                this._CmsEditThemeService.pageZoneDragStartStyle();
                /*sürüklenen elementin ayarlarını transferet*/
                event.dataTransfer.setData('text/plain', item.getAttribute("data-widget-settings"));
            });

            item.addEventListener('dragend', () => {
                this._CmsEditThemeService.pageZoneDragEndStyle();
            });
        }
    }

    /**
     * Modal buttonları
     */
    modalButtonHandler = () => {
        document.querySelectorAll(`[data-cms-modal-id]`).forEach((btn) => {
            window.HelperFunction.modalEvent(btn);
        });
    }


    


    execute = () => {
        this.topMenuButtonHandler();
        this.widgetsButtonHandler();
        this.createObjectZone();
        this.modalButtonHandler();
        this.widgetsDraggableHandler();
    }
}


const cmsEditPage = new CmsEditPage();
cmsEditPage.execute();


