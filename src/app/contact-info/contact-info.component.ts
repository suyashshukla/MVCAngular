import { Component, Input, Output, EventEmitter} from '@angular/core';
import { FormService } from '../form-service';
import { Home } from '../Home';
@Component({
  selector: 'app-info',
  templateUrl: './contact-info.component.html',
  styleUrls: ['./contact-info.component.css']
})

export class ContactInfo {

  constructor(private services: FormService) {}

  @Input() details = new Home();
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
      this.triggerRefresh.emit();
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
