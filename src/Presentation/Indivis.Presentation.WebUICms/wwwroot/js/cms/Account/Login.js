import HelperFunctions from '../Helpers/HelperFunctions.js'
import { BaseService } from '../Base/BaseService.js'


export default class LoginService extends BaseService {

    /**
     * 
     * @param {string} formClassName
     * @param {string} path
     */
    constructor(formClassName, path) {
        super(formClassName,path);
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
    submitHandler(e) {

        const formData = HelperFunctions.formDataToJsonObject(new FormData(e.target));

        fetch(this.Path, {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        }).then(res => {
            return res.json();
        }).then(json => {
            console.log(json);
        })
    }


    
}



