
export default {

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