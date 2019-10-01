import { Injectable } from '@angular/core';

@Injectable()

export class FormService {

  contacts = [
    {
      name: 'Suyash Shukla',
      email: 'imsuyash97@gmail.com',
      mobile: '8319279074',
      landline: '7896541236',
      address: 'Gayatri Nagar, Hyderabad',
      website : 'www.kavyastrot.com'
    },
    {
      name: 'Jimmy Jacobs',
      email: 'jacobs@gmail.com',
      mobile: '9896541232',
      landline: '022541636',
      address: 'Capetown, SA',
      website: 'www.biz.sa'
    },
    {
      name: 'Arnold Johannes',
      email: 'swachhnegar@termite.com',
      mobile: '9856321452',
      landline: '2255669988',
      address: 'Rio De Janeiro, Brazil',
      website: 'www.bewink.com'
    },
    {
      name: 'Matt Narasimgha',
      email: 'matthew.n@slti.com',
      mobile: '8236548954',
      landline: '9856956523',
      address: 'Rajapaksha, Sri Lanka',
      website: 'www.nomad.sl'
    },
    {
      name: 'Chris Tremlett',
      email: 'chris97@gmail.com',
      mobile: '8745963542',
      landline: '7896541236',
      address: 'Down Town, Britain',
      website: 'www.ecb.co.uk'
    }];

  formVisibility = false;
  formData = {};

  addContact(addC) {
    this.contacts.push(addC);
  }

  removeContact(removeC) {
    this.contacts = this.contacts.filter(c => c != removeC);
  }

  showForm(fData) {
    this.formVisibility = true;
    this.formData = fData;
  }

  getContacts() {
    return this.contacts;
  }

  updateContact(updateC, originalC) {
    this.contacts[this.contacts.indexOf(originalC)] = updateC;
    this.formData = updateC;
  }

}
