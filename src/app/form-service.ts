import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Home } from './Home';

@Injectable()

export class FormService {

  constructor(private http: HttpClient) { }


  contacts;

  formVisibility = false;
  formData: Home;
  url = "/api/data";

  syncData() {
    return this.http.get(this.url);
  }

  addContact(addC) {
    this.contacts.push(addC);
  }

  removeContact(removeC) {
    this.contacts = this.contacts.filter(c => c != removeC);
  }

  showForm(fData:Home) {
    this.formVisibility = true;
    this.formData = fData;
  }

  getContacts() {
    this.contacts = [];
    return this.contacts;
  }



 
  fetchURL() {
    return this.http.get<Home[]>(this.url)
  }

  getURL(id) {
    return this.http.get<Home>(this.url + "/" + id);
  }

  postURL(data) {
    return this.http.post<Home>(this.url,data);
  }

  putURL(data) {
    return this.http.put<Home>(this.url,data);
  }

  deleteURL(data) {
    return this.http.delete(this.url+"/"+data.id);
  }

  updateContact(updateC, originalC) {
    this.contacts[this.contacts.indexOf(originalC)] = updateC;
    this.formData = updateC;
  }

}
