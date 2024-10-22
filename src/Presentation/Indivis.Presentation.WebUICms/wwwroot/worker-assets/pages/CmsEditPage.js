import { PageWidgetTemplateService } from '../services/EditPage/PageWidgetTemplateService.js'
import { LocalizationService } from '../services/EditPage/LocalizationService.js'
import { HelperFunction } from '../services/helpers/HelperFunctions.js'

export class CmsEditPage {

    constructor() {
        /**
         * @type {PageWidgetTemplateService}
         */
        this._PageWidgetTemplateService = new PageWidgetTemplateService();
        /**
         * @type {LocalizationService}
         */
        this._Localization = new LocalizationService();
    }

    /**
     * Zone nesnelerini oluştur
     */
    createObjectZone = () => {
        window.addEventListener('load', async (e) => {
            this._PageWidgetTemplateService.createObjectZone(e);
            await this._PageWidgetTemplateService.pageZoneExecuteAsync();
            
        });
    }

    /**
     * Mobil menu toggle
     */
    topMenuButtonHandler = () => {
        const button = document.querySelector(".js-top-menu-button");
        button.addEventListener('click', function (e) {
            const menu = document.querySelector(".cms-editpage-top__menu__group");
            HelperFunction.toggleClass(menu, "cms-editpage-top__menu__group--toggle");
        })
    }

    /**
     * Yeni widget ekleme alanı aç/kapa toggle
     */
    widgetsButtonHandler = () => {
        const button = document.querySelector(".js-cms-editpage-widget-button");

        button.addEventListener('click', function (e) {
            const btn = document.querySelector(".cms-editpage-widget");
            HelperFunction.toggleClass(btn, "cms-editpage-widget--toggle");
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
                this._PageWidgetTemplateService.pageZoneDragStartStyle();
                /*sürüklenen elementin ayarlarını transferet*/
                event.dataTransfer.setData('text/plain', item.getAttribute("data-widget-settings"));
            });

            item.addEventListener('dragend', () => {
                this._PageWidgetTemplateService.pageZoneDragEndStyle();
            });
        }
    }

    /**
     * Modal buttonları
     */
    modalButtonHandler = () => {
        document.querySelectorAll(`[data-cms-modal-id]`).forEach((btn) => {
            HelperFunction.modalEvent(btn);
        });
    }


    


    execute = () => {
        this.topMenuButtonHandler();
        this.widgetsButtonHandler();
        this.createObjectZone();
        this.modalButtonHandler();
        this.widgetsDraggableHandler();
        this._Localization.executeAsync();
    }
}


const cmsEditPage = new CmsEditPage();
cmsEditPage.execute();


