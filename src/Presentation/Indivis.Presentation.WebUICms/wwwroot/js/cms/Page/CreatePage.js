import HelperFunctions from '../Helpers/HelperFunctions.js'
import { BaseService } from '../Base/BaseService.js'

export default class CreatepageService extends BaseService {


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
     * @param {Event} e
     */
    validation(e) {
        if (e.target.querySelector(`input[name="Email"]`).value.length <= 4) {
            throw new Error("Email adresi 4 karakterden az olamaz");
        }

        if (e.target.querySelector(`input[name="Password"]`).value.length < 6) {
            throw new Error("Şifre en az 6 karakter olamlı");
        }
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
            return res.json();
        }).then(json => {

            if (json.isSuccess == true) {

                window.location.pathname = "/home/index";
            } else {
                alert("Kullanıcı adı veya şifre yanlış");
            }
            console.log(json);
        })
    }
}