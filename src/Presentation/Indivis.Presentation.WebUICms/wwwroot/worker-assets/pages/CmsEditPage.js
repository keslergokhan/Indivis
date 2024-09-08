import { CmsEditThemeService } from '../services/shared/CmsEditThemeService.js'

export class CmsEditPage {

    constructor() {
        /**
         * @type {CmsEditThemeService}
         */
        this._CmsEditThemeService = new CmsEditThemeService();
    }

    
    createObjectZone = () => {
        window.addEventListener('load', (e) => {
            this._CmsEditThemeService.createObjectZone(e);
            this._CmsEditThemeService.pageZoneExecute();
        });
    }

    topMenuButtonHandler = () => {
        const button = document.querySelector(".js-top-menu-button");
        button.addEventListener('click', function (e) {
            const menu = document.querySelector(".cms-editpage-top__menu__group");
            window.HelperFunction.toggleClass(menu, "cms-editpage-top__menu__group--toggle");
        })
    }


    //settingsButtonHandler = () => {
    //    const button = document.querySelector(".js-cms-editpage-setting-button");

    //    button.addEventListener('click', function (e) {
    //        const btn = document.querySelector(".cms-editpage-setting");
    //        window.HelperFunction.toggleClass(btn, "cms-editpage-setting--toggle");
    //    });
    //}

    modalButtonHandler = () => {
        document.querySelectorAll(`[data-cms-modal-id]`).forEach((btn) => {
            window.HelperFunction.modalEvent(btn);
        });
    }

   
    execute = () => {
        this.topMenuButtonHandler();
        //this.settingsButtonHandler();
        this.createObjectZone();
        this.modalButtonHandler();
    }
}


const cmsEditPage = new CmsEditPage();
cmsEditPage.execute();


