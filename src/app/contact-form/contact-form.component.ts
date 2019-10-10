import { Component,Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

import { FormService } from '../form-service';

import { Home } from '../Home';


@Component({
  selector: 'app-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})

export class ContactForm {

  @Input() editData = new Home();

  @Output() closeLightBox = new EventEmitter();

  addForm;

  constructor(private service: FormService,
    private router : Router,
      private formBuilder: FormBuilder) {


    this.addForm = this.formBuilder.group(
      {
      id: '',
      name: '',
      email: '',
      phone: '',
      landline: '',
      address: '',
      website : '',
    }

    )

  }

  isVacant(obj) {
    for (var key in obj) {
      if (obj[key] != "")
        return false;
    }
    return true;
  }

  isIncomplete(obj) {
    var flag = false;
    for (var key in obj) {
      if(key == 'id')
      continue;
      if (obj[key] == "") {
        flag = true;
        break;
      }
    }
    return flag;
  }

  addNew(contact: Home) {

      console.log(this.editData);

    if (!this.isVacant(this.editData)) { //For checking update instance
      contact = {
        id: this.editData.id,
        name: contact.name != "" ? contact.name : this.editData.name,
        phone: contact.phone != "" ? contact.phone : this.editData.phone,
        email: contact.email != "" ? contact.email : this.editData.email,
        address: contact.address != "" ? contact.address : this.editData.address,
        website: contact.website != "" ? contact.website : this.editData.website,
        landline: contact.landline != "" ? contact.landline : this.editData.landline,
      }

      this.service.putURL(contact).subscribe((res) => {
        console.log("Update : " + res.toString() != "1" ? "Success" : "Fail");
        this.addForm.reset();
        this.editData = new Home();
        this.service.closeForm(contact);
      });
    }
    else if (!this.isIncomplete(contact)) {  //for checking incomplete form instance
      this.service.postURL(contact).subscribe((res) => {
        console.log("Created: " + res.toString() != "1" ? "Success" : "Fail");
        this.addForm.reset();
        this.editData = new Home();
      });
    }
    else { //for checking error cases
      window.alert("Invalid Data Entries");
    }

    this.closeForm();
    
  }

  closeForm() {
    this.router.navigate(['']);
  }

}
