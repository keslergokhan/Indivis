import HelperFunctions from '../Helpers/HelperFunctions.js'
import { BaseService } from '../Base/BaseService.js'

export default class CreatePageService extends BaseService {


    /**
     * 
     * @param {string} formClassName
     * @param {string} path
     */
    constructor(formClassName, path) {
        super(formClassName, path);
    }

    /**
     * 
     * @param {JustValidate} justValidate
     */
    justValidate(justValidate) {

        justValidate
            .addField(`[name="Name"]`, [
                {
                    rule: 'required',
                    errorMessage: 'Kullanıcı adı gereklidir',
                },
                {
                    rule: 'minLength',
                    value: 3,
                    errorMessage: 'Kullanıcı adı en az 3 karakter olmalıdır',
                },
                {
                    rule: 'maxLength',
                    value: 20,
                    errorMessage: 'Kullanıcı adı en fazla 20 karakter olmalıdır',
                },
            ])
    }

    /**
     * 
     * @param {ParentNode} e
     */
    eventHandlerAsync(form) {
        form.querySelector(`[name="Slug"]`).addEventListener('keydown', (e) => {
            let newKey = HelperFunctions.translateTextToSlug(e.target.value);
            e.target.value = newKey;
        });
    }

    /**
     * 
     * @param {Event} e
     */
    async submitHandlerAsync(e) {
        const formData = HelperFunctions.formDataToJsonObject(new FormData(e.target));

        await fetch(this.Path, {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        }).then(res => {
            //return res.json();
        }).then(json => {

            
        })
    }
}