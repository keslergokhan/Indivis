import { CmsAlert } from "../helpers/HelperFunctions.js";

export class LocalizationService {

    constructor() {
        /** @type {Array<Localization>} */
        this.Localizations = []
    }

    /**
     * Yeni localization nesneleri oluştur.
     */
    createLocalizatonObject = () => {
        document.querySelectorAll(".js-cms-loc-key").forEach(loc => {
            this.Localizations.push(new Localization(loc));
        });
    }

    

    executeAsync = async () => {
        this.createLocalizatonObject();
        setTimeout(async () => {
            for (const loc of this.Localizations) {
                await loc.executeAsync();
            }
        }, 1000);
    }
}


class LocalizationData {
    constructor({ id, key, defaultValue, isHtmlEditor,region }) {
        /** @type {string} */
        this.Id = id;
        /**  Varsayılan değer @type {string} */
        this.DefaultValue = defaultValue;
        /** CkEditor @type {boolean}*/
        this.IsHtmlEditor = isHtmlEditor;
        /** @type {string} Benzersiz key*/
        this.Key = key;
        /** Diğer Diller @type {Array<LocalizationData>}*/
        this.Region = region;
    }

    /**
     * 
     * @param {Array<LocalizationData>} regions
     */
    setRegion = (regions) => {
        this.Region.push(regions)
    }
}
class Localization {

    constructor(localizationElement) {
        /** @type {Element} */
        this.LocalizationElement = localizationElement;
        /** @type {LocalizationData} */
        this.LocalizationData = null;
        this.CkEditorObject = null;
    }

    /**
     * Localization key döndürür
     * @returns {string}
     */
    getLocalizationKey = () => {
        return this.LocalizationElement.getAttribute("data-loc-key");
    }

    /**
     *  Localization Id(Guid) döndürür
     * @returns {string}
     */
    getLocalizationDbId = () => {
        return this.LocalizationElement.getAttribute("data-loc-id");
    }

    /**
     * Elementin Id değerini döndürür.
     * @returns {string}
     */
    getLocalizationId = () => {
        return this.LocalizationElement.getAttribute("id");
    }

    /**
     * Localization click event
     */
    localizationClickHandlerAsync = async () => {
        this.LocalizationElement.addEventListener('click', () => {

        })
    }

    /**
     * Localization db data
     */
    getLocalizationDbDataAsync = async () => {
        await fetch(`/api/LocalizationCmsApi/get-localization/${this.getLocalizationKey()}`)
            .then(res => res.json())
            .then(json => {
                if (json.isSuccess) {
                    this.LocalizationData = new LocalizationData(json.data);
                }
            }).catch(x => {
                CmsAlert.error("Uyarı", "Beklenmedik teknik bir problem yaşandı, lütfen daha sonra tekrar deneyiniz !");
                console.error(x);
                console.log("getLocalizationDbDataAsync");
            })
    }

    /**
     * CkEditor nesnesi döndürür.
     * @param {any} id
     * @returns
     */
    getCreateCkEditorObject = (id) => {
        /*
        this.CkEditorObject = CKEDITOR.replace('editor', {
            height: 300, // Editör yüksekliği
            toolbar: [
                { name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print'] },
                { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'Undo', 'Redo'] },
                { name: 'editing', items: ['Find', 'Replace'] },
                { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline'] },
                { name: 'paragraph', items: ['NumberedList', 'BulletedList'] },
                { name: 'insert', items: ['Image', 'Table'] },
            ]
        });
        */
    }

    localizationCkEditorHandlerAsync = async () => {
        this.getCreateCkEditorObject(this.getLocalizationId())
    }

    executeAsync = async () => {
        await this.getLocalizationDbDataAsync();
        await this.localizationClickHandlerAsync();
        if (this.LocalizationData.IsHtmlEditor) {
            this.localizationCkEditorHandlerAsync();
        } else {

        }
    }
}