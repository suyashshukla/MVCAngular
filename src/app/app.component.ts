import { Component, OnInit } from '@angular/core';
import { FormService } from './form-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  formFlag = false;

  dataFlag;

  infoContent;

  contacts = [];

  constructor(private contactService: FormService) { }

  ngOnInit() {
    this.fetchData();
  }

  fetchData() {
    this.contacts = this.contactService.getContacts();
    this.infoContent = this.contactService.formData;
    this.checkValidity();
  }

  editFormVisible() {
    this.formFlag = this.contactService.formVisibility;
  }

  checkValidity() {
    this.dataFlag = this.contacts.length != 0;
  }


  closeForm() {
    this.formFlag = false;
  }

  toggleForm() {
    this.infoContent = {};
    this.formFlag = true;
  }

  display(contact) {
    this.infoContent = contact;
  }

  closeBox() {
    this.formFlag = false;
    this.fetchData();
  }

}
