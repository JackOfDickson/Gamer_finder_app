import CryptoJS from 'crypto-js';

const secretKey = 'your-secret-key'; // Used for encryption
//will worry about adding iv later
// const iv = CryptoJS.lib.WordArray.random(16) //Generate random IV

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


// import crypto from 'crypto';

// const secretKey = "Replace_this_with_your_own_hidden_key"
// const iv = crypto.randomBytes(16)

// const encryptData = (data: string): { iv: Buffer, encryptedData: string } => {
//     const cipher = crypto.createCipheriv("aes-256-cbc", Buffer.from(secretKey), iv)
//     let encryptedData = cipher.update(data, 'utf-8', 'base64')
//     encryptedData += cipher.final('base64')
//     return { iv, encryptedData }
// }

// const decryptData = (encryptedData: string, iv: Buffer): string => {
//     const decipher = crypto.createDecipheriv('aes-256-cbc', Buffer.from(secretKey), iv);
//     let decryptedData = decipher.update(encryptedData, 'base64', 'utf-8');
//     decryptedData += decipher.final('utf-8');
//     return decryptedData;
// };

export {encryptData as encryptData, decryptData as decryptData};