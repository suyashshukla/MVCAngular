import { Component,Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { FormService } from '../form-service';


@Component({
  selector: 'app-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})

export class ContactForm {

  @Input() editData;
  
  @Output() closeLightBox = new EventEmitter();

  addForm;
  
  constructor(private service : FormService,
    private formBuilder : FormBuilder){

    this.addForm = this.formBuilder.group(
      {
        name: '',
        email : '',
        mobile : '',
        landline : '',
        website : '',
        address : ''
      }
    )

  }

  isVacant(obj) {
  for (var key in obj) {
    if (obj[key]!="")
      return false;
  }
  return true;
}

  addNew(contact) {

      var uContact = {
        name: contact['name'] != "" ? contact['name'] : this.editData['name'],
        email: contact['email'] != "" ? contact['email'] : this.editData['email'],
        mobile: contact['mobile'] != "" ? contact['mobile'] : this.editData['mobile'],
        landline: contact['landline'] != "" ? contact['landline'] : this.editData['landline'],
        website: contact['website'] != "" ? contact['website'] : this.editData['website'],
        address: contact['address'] != "" ? contact['address'] : this.editData['address'],
    }




    if (this.service.getContacts().indexOf(this.editData) >= 0) {
      this.service.updateContact(uContact, this.editData);
      this.addForm.reset();
      this.editData = {};
    }
    else if (!this.isVacant(contact)) {
      this.service.addContact(contact);
      this.addForm.reset();
    }


    this.closeLightBox.emit();
    
   
  }

}
