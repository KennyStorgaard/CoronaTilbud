//inputs
var inputCoronaOffer = document.getElementById("coronaoffer");
var inputCompanyName = document.getElementById("companyname");
var inputCompanyPhone = document.getElementById("companyphone");
var inputCompanyEmail = document.getElementById("companyemail");
var inputCompanyHeadline = document.getElementById("headline");

//html
var offerCompanyName = document.getElementById("offercompanyname");
var offerHeadline = document.getElementById("offerheadline");
var offerEmail = document.getElementById("offeremail");
var offerContactInfo = document.getElementById("offercontactinfo");
var offerHomepage = document.getElementById("offerhomepage");
var offerPreviewText = document.getElementById("offerpreviewtext");
var offerPhone = document.getElementById("offerphone");
var emailLink = document.getElementById("emaillink");
//All inputs
var createAddForm = document.getElementById("createaddform");
var allInputs = createAddForm.querySelectorAll('input');
console.log(allInputs);

//Company Name
inputCompanyName.onkeyup = function () {
    if (offerCompanyName.innerHTML.length <= 1) {
        offerCompanyName.innerHTML = "Firma Navn";
    } else {
        offerCompanyName.innerHTML = this.value;
    }
}

//Headline
inputCompanyHeadline.onkeyup = function () {
    if (offerHeadline.innerHTML.length <= 1) {
        offerHeadline.innerHTML = "Overskrift";
    } else {
        offerHeadline.innerHTML = this.value;
    }
}

//Offer
inputCoronaOffer.onkeyup = function () {
    console.log(offerPreviewText.innerHTML.length)
    if (offerPreviewText.innerHTML.length <= 1) {
        offerPreviewText.innerHTML = "Corona tilbud - max 250 tegn";
    } else {
        offerPreviewText.innerHTML = this.value;
    }

}

//Phone
inputCompanyPhone.onkeyup = function () {
    if (offerPhone.innerHTML.length <= 1) {
        offerPhone.innerHTML = "Telefon: ";
    } else {
        offerPhone.innerHTML = "Telefon: " + this.value;
    }

}

//Email
inputCompanyEmail.onkeyup = function () {
    if (offerEmail.innerHTML.length <= 1) {
        offerEmail.innerHTML = "Email: ";
    } else {

        emailLink.href = "mailto:" + this.value
        emailLink.innerHTML = this.value;

    }

}
