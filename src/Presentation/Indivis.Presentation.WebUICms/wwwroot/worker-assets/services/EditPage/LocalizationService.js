export class LocalizationService {

    constructor() {
        /** @type {Array<Localization>} */
        this.Localizations = []
    }

    createLocalizatonObject = () => {
        document.querySelectorAll(".js-cms-loc-key").forEach(loc => {
            console.log(loc);
            this.Localizations.push(loc);
        });
    }

    execute = () => {
        this.createLocalizatonObject();
        console.log("Localizaton başladı ");
    }
}



class Localization {

    constructor(localizationElement) {
        /** @type {Element} */
        this.LocalizationElement = localizationElement;
    }



    execute = () => {

    }
}