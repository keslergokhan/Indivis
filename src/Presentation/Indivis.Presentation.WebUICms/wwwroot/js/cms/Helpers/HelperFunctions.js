
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

        invalidUrlCharacters.forEach((x) => {
            text = text.replace(x, '').replace(' ','-');
        });

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
    }
}