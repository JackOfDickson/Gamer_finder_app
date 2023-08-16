import CryptoJS from 'crypto-js';

const secretKey = 'your-secret-key';

const encryptData = (data: string): string => {
    console.log(data)
    const encrypted = CryptoJS.AES.encrypt(data, secretKey )
    return encrypted.toString()
};

const decryptData = (encryptedData: string): string => {
    const decryptedBytes = CryptoJS.AES.decrypt(encryptedData, secretKey)
    const decryptedString = decryptedBytes.toString(CryptoJS.enc.Utf8)
    return decryptedString;
};

export {encryptData , decryptData};