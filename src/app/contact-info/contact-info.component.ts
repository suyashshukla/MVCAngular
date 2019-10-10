import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormService } from '../form-service';
import { Home } from '../Home';
@Component({
  selector: 'app-info',
  templateUrl: './contact-info.component.html',
  styleUrls: ['./contact-info.component.css']
})

export class ContactInfo {

  id;
  details;

  constructor(private services: FormService,
    private router: ActivatedRoute,
    private route: Router
  ) {
    router.paramMap.subscribe((data) => {
      this.id = data.get('id');
      this.services.getURL(this.id).subscribe((contact) => {
        this.details = contact;
      });
    })
  }

  
  @Output() triggerRefresh = new EventEmitter();
  @Output() triggerForm = new EventEmitter();

  editData() {
    console.log("address = " + this.details.address);
    this.services.showForm(this.details);
    this.triggerForm.emit();
  }

  deleteData() {
    this.services.deleteURL(this.details).subscribe((res) => {
      console.log("Delete : " + res.toString() == "1" ? "Success" : "Fail : ");
      this.details = new Home();
    });
  }

  isEmpty(obj) {
  for (var key in obj) {
    if (obj.hasOwnProperty(key))
      return false;
  }
  return true;
}
  }
