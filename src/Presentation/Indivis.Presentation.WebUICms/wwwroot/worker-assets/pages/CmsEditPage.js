
import { HelperFunction } from '../services/helpers/HelperFunctions.js'
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
        });
    }

    topMenuButtonHandler = () => {

        const button = document.querySelector(".js-top-menu-button");
        button.addEventListener('click', function (e) {
            const menu = document.querySelector(".cms-editpage-top__menu__group");
            HelperFunction.toggleClass(menu, "cms-editpage-top__menu__group--toggle");
        })
    }


    settingsButtonHandler = () => {
        const button = document.querySelector(".js-cms-editpage-setting-button");


        button.addEventListener('click', function (e) {
            const btn = document.querySelector(".cms-editpage-setting");
            HelperFunction.toggleClass(btn, "cms-editpage-setting--toggle");
        });
    }

   
    execute = () => {
        this.topMenuButtonHandler();
        this.settingsButtonHandler();
        this.createObjectZone();
    }
}


const cmsEditPage = new CmsEditPage();
cmsEditPage.execute();


