
export const JustValidateMessage = {
    /**
    * Lütfen boş bırakmayınız !
    * @returns {string}
    */
    required: () => "Lütfen boş bırakmayınız !",
    /**
     * En az {a} karakter olabilir !
     * @param {Int32Array} a
     * @returns {string}
     */
    minLenght: (a) => `En az ${a} karakter olabilir !`,
    /**
     * En az {a} karakter olabilir !
     * @param {Int32Array} a
     * @returns {string}
     */
    maxLenght: (a) => `En çok ${a} karakter olabilir !`,
    /**
     * Lütfen uygun bir format giriniz !
     * @returns {string}
     */
    email:()=>"Lütfen uygun bir format giriniz !"

}


export const HelperFunction = {

    /**
     * 
     * @param {string} text
     * @returns {string}
     */
    translateTextToSlug:(text) => {
        let invalidUrlCharacters = ['+', '&', '=', '?', '%', '#', '/', '\\', ';', ':', '@', '[', ']', '{', '}', '<', '>', '"', '\'', '^', '`', '|', '~', '!', '$', '(', ')', '*']; 

        let replaceArray = [
            ["ı", "i"],
            ["ö", "o"],
            ["ü", "u"],
            ["ç", "c"],
            ["ş", "s"],
            ["ğ","g"]
        ];

        invalidUrlCharacters.forEach((x) => {
            text = text.replace(x, '').replace(' ','-');
        });

        replaceArray.forEach(x => {
            text = text.replace(x[0], x[1]);
        })

        return `/${text}`;
    },
    /**
     * formdata elemanlarını key:value şeklinde object dönüştürür
     * @param {FormData} formData
     * @return {object}
     */
    formDataToJsonObject:(formData) => {
        var jsonObject = {};

       
        formData.forEach(function (value, key) {

            let keys = key.split('.'); // 'Page.Title' string'ini '.' ile ayırıp bir diziye atayalım
            let currentObj = jsonObject;

            // Objeyi iç içe olacak şekilde oluşturalım
            for (let i = 0; i < keys.length; i++) {
                if (i === keys.length - 1) {
                    currentObj[keys[i]] = value; // Son öğede değeri ekleyelim
                } else {
                    currentObj[keys[i]] = currentObj[keys[i]] || {}; // Objeyi oluşturalım
                    currentObj = currentObj[keys[i]]; // Sonraki öğeye geçelim
                }
            }
            
            
        });


        return jsonObject;
    },

    /**
     * 
     * @param {ParentNode} element toggle işlemi uygulanacak element
     * @param {string} toggleClass toggle aktif olacak class
     */
    toggleClass:(element,toggleClass) => {
        if ([...element.classList].indexOf(toggleClass) == -1) {
            element.classList.add(toggleClass);

        } else {
            element.classList.remove(toggleClass);
        }
    }
}