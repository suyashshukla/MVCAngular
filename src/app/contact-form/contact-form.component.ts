import { Component,Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';

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
    private formBuilder: FormBuilder) {

    this.addForm = this.formBuilder.group({
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

  addNew(contact: Home) {

    if (!this.isVacant(this.editData)) {
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
      });
    }
    else {
      this.service.postURL(contact).subscribe((res) => {
        console.log("Created: " + res.toString() != "1" ? "Success" : "Fail");
        this.addForm.reset();
        this.editData = new Home();
      });
    }

    this.closeLightBox.emit();


  }

  generateJSON(data) {
    return {
      id: data.id,
      name: data.name,
      email: data.email,
      phone: data.phone,
      landline: data.landline,
      website: data.website,
      address: data.address
    }

  }
}
