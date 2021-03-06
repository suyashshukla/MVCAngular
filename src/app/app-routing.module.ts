import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactInfo } from './contact-info/contact-info.component'
import { BlankComponent } from './blank/blank.component';
import { ContactForm } from './contact-form/contact-form.component';
import { Home } from './Home';


const routes: Routes = [
  { path: 'contact/:id', component: ContactInfo },
  { path: '', component: BlankComponent },
  { path: 'forms', component: ContactForm },
  { path: 'forms/:id', component: ContactForm }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash : true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
