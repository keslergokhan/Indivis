import { CmsAlert } from "../helpers/HelperFunctions.js";

export class LocalizationService {

    constructor() {
        /** @type {Array<Localization>} */
        this.Localizations = [];
    }

    /**
     * Yeni localization nesneleri oluştur.
     */
    createPageLocalizatonObject = () => {
        document.querySelectorAll(".js-cms-loc-key").forEach(loc => {
            this.Localizations.push(new Localization(loc));
        });
    }

    createPageWidgetLocalizationObject = () => {
        document.querySelectorAll(".js-cms-widget-loc-key").forEach(loc => {
            const newArray = this.Localizations.filter(x => x.key != loc.key);
            this.WidgetLocalization = newArray;
        });
    }

    executeWidgetAsync = () => {
        this.createPageWidgetLocalizationObject();
        setTimeout(async () => {
            for (const loc of this.WidgetLocalization) {
                await loc.executeAsync();
            }
        },500)
    }

    executeAsync = async () => {
        this.createPageLocalizatonObject();
        setTimeout(async () => {
            for (const loc of this.Localizations) {
                await loc.executeAsync();
            }
        }, 500);
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
            this.localizationCkEditorHandlerAsync();
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
        this.CkEditorObject = CKEDITOR.replace(`${id}`, {
            height: 75,
            width: 'auto'
        });

        this.ckEditorSaveButton();
        this.ckEditorCloseButton();
        
    }

    ckEditorSaveButton = () => {
        this.CkEditorObject.addCommand('LocalizationSaveHandler', {
            exec: function (edit) {
                alert("sdfsdf");
            }
        });

        this.CkEditorObject.ui.addButton('LocalizationSave', {
            label: "Kaydet",
            command: "LocalizationSaveHandler",
            toolbar: 'insert',
            icon: '/styles-assets/media/floppy-disk.svg'
        });
    }

    ckEditorCloseButton = () => {
        this.CkEditorObject.addCommand('LocalizationCloseHandler', {
            exec: () => {
                this.CkEditorObject.destroy();
            }
        });

        this.CkEditorObject.ui.addButton('LocalizationClose', {
            label: "İptal",
            command: "LocalizationCloseHandler",
            toolbar: 'insert',
            icon: '/styles-assets/media/xmark.svg'
        });
    }

    localizationCkEditorHandlerAsync = async () => {
        this.getCreateCkEditorObject(this.getLocalizationId())
    }

    executeAsync = async () => {
        await this.getLocalizationDbDataAsync();
        await this.localizationClickHandlerAsync();
        if (this.LocalizationData.IsHtmlEditor) {
            
        } else {

        }

        
    }
}