import { HelperFunction, JustValidateMessage } from '../Helpers/HelperFunctions.js'
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
                    errorMessage: JustValidateMessage.required(),
                },
                {
                    rule: 'minLength',
                    value: 3,
                    errorMessage: JustValidateMessage.minLenght(3),
                },
                {
                    rule: 'maxLength',
                    value: 20,
                    errorMessage: JustValidateMessage.maxLenght(20),
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
        const formData = HelperFunction.formDataToJsonObject(new FormData(e.target));

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