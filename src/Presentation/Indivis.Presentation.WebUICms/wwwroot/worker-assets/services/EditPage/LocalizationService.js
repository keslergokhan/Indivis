import { CmsAlert } from "../helpers/HelperFunctions.js";

export class LocalizationService {

    /** @type {Array<Localization>} */
    static Localizations = [];
    constructor() {
        
    }

    /**
     * Yeni localization nesneleri oluştur.
     */
    createPageLocalizatonObject = () => {
        document.querySelectorAll(".js-cms-loc-key").forEach(loc => {
            const localization = new Localization(loc);
            if (LocalizationService.Localizations.findIndex(x => x.getLocalizationId() == localization.getLocalizationId()) <= -1) {
                LocalizationService.Localizations.push(localization);
            }
        });
    }

    /**
     * Zone yapıları içerisindeki localization nesnesini oluştur ve çalıştır.
     * @param {Element} pageZoneElement
     */
    static createAndExecutePageWidgetLocalizationAsync = async (pageZoneElement) => {
        const zoneLocs = document.querySelectorAll(".js-cms-widget-loc-key");

        for (const loc of zoneLocs) {

            /** @type {Localization} */
            const localization = new Localization(loc);

            if (LocalizationService.Localizations.findIndex(x => x.getLocalizationId() == localization.getLocalizationId()) <= -1) {
                LocalizationService.Localizations.push(localization);
            } else {
                const index = LocalizationService.Localizations.findIndex(x => x.key == localization.getLocalizationKey());
                LocalizationService.Localizations[index] = localization;
            }
            await LocalizationService.localizationAllRunExecuteAsync();
        }
    }


    static localizationAllRunExecuteAsync = async () => {
        setTimeout(async () => {
            for (const loc of LocalizationService.Localizations) {
                if (!loc.RunExecuteControl) {
                    loc.RunExecuteControl = true;
                    await loc.executeAsync();
                }
            }
        }, 500);
    }


   /**
    * Aynı olan localization değerleri güncelle
    * @param {Localization} Localization
    * @param {string} value
    */
    static localizationAllUpdateValueAsync = async (localization,value) => {

        const filterResult = LocalizationService.Localizations.filter(x => x.getLocalizationDbId() == localization.getLocalizationDbId())

        if (filterResult) {
            for (const loc of filterResult) {
                loc.LocalizationElement.innerHTML = value;
            }
        }
        
    }

    executeAsync = async () => {
        this.createPageLocalizatonObject();
        await LocalizationService.localizationAllRunExecuteAsync();
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
        this.RunExecuteControl = false;
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

    valueSaveAsync = async () => {

        const req = {
            Localization: {
                LocalizationId: this.getLocalizationDbId(),
                Key: this.getLocalizationKey(),
                Value: this.CkEditorObject.getData()
            }
        };

        const settings = {
            method:'POST',
            body: JSON.stringify(req),
            headers: {
                'Content-Type': 'application/json',
            }
        };

        await fetch('/api/localizationCmsApi/update-localization', settings)
            .then(x => x.json())
            .then(async json => {

                console.log(json);
                if (json.isSuccess) {
                    CmsAlert.success("İşlem Başarılı", "Metin başarıyla güncellendi !");
                    this.CkEditorObject.destroy();
                    await LocalizationService.localizationAllUpdateValueAsync(this, json.data.region[0].value);
                } else {
                    CmsAlert.error("Uyarı !", "Beklenmedik teknik bir problem yaşandı lütfen daha sonra tekrar deneyin !");
                    console.error(json);
                    console.error("valueSaveAsync");
                }
            })
            .catch(x => {
                CmsAlert.error("Uyarı !", "Beklenmedik teknik bir problem yaşandı !");
                console.error(x);
                console.log("valueSaveAsync");
            });

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
            exec: () => {
                this.valueSaveAsync();
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
        this.LocalizationData.RunExecuteControl = true;
    }
}