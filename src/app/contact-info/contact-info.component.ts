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
  details:Home;

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


  editData() {
    console.log("address = " + this.details.address);
    this.route.navigate(['forms/',this.id]);
  }

  deleteData() {
    this.services.deleteURL(this.details).subscribe((res) => {
      console.log("Delete : " + res.toString() == "1" ? "Success" : "Fail : ");
      this.route.navigate(['']);
      this.services.refreshRoot();
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
