import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormationService } from './../../shared/formation.service';
import { NgForm,FormGroup, FormControl } from '@angular/forms';
import { Pipe, PipeTransform } from '@angular/core';
import { FilterPipe } from 'node_modules/ngx-filter-pipe';
import { NotificationService } from '../../shared/Notification.service';

//import 'rxjs/add/operator/startWith';
@Component({
  selector: 'app-dropdowns',
  templateUrl: './dropdowns.component.html',
  styles: []
})

@Pipe({
  name: 'filterBy',
  pure: false
})

export class DropdownsComponent implements OnInit {

  heading = 'Dropdowns';
  subheading = 'Multiple styles, actions and effects are available for the ArchutectUI dropdown buttons.';
  icon = 'pe-7s-umbrella icon-gradient bg-sunny-morning';
 // objectsWithGettersFilter: any = { name: null };

  constructor(private modalService: NgbModal, public notification: NotificationService,private filter: FilterPipe,public formation: FormationService, private toastr: ToastrService ) {
   
    this.formation.getUserList().subscribe(
      data => {
        Object.assign(this.userData, data);
      },
      error => {
        console.log("Something wrong here");
      });    
 
 
    console.log(filter.transform(this.formation.participants, { test: 'value' }));
  }
   
  
  userData: any[] = [];
  userList1 : any[]= []
  lastkeydown1: number = 0;
  subscription: any;
 

  
 // searchTerm: string;
  
//procedure de filtrage
//transform() {
//this.formation.participants=this.formation.participants.filter(res=>{
 //return res.name.toLocaleLowerCase().match(this.searchText.toLocaleLowerCase()) ;
//}) ;
 
//}


getUserIdsFirstWay($event) {
  let userId = (<HTMLInputElement>document.getElementById('userIdFirstWay')).value;
  this.userList1 = [];

  if (userId.length > 2) {
    if ($event.timeStamp - this.lastkeydown1 > 200) {
      this.userList1 = this.searchFromArray(this.userData, userId);
    }
  }
}  

searchFromArray(arr, regex) {
  let matches = [], i;
  for (i = 0; i < arr.length; i++) {
    if (arr[i].match(regex)) {
      matches.push(arr[i]);
    }
  }
  return matches;
};





  open(content) {
    this.modalService.open(content).result.then((result) => {
     
    }, (reason) => {
    
    });
  }

  openCentred(content) {
    this.modalService.open(content, { centered: true });
  }

  openSmall(content1) {
    this.modalService.open(content1, {
      size: 'sm'
    });
  }

  openLarge(content) {
    this.modalService.open(content, {
      size: 'lg'
    });
  }
  stringsFilter = '';
  userFilter: any = { userName: '' };
  objectsFilter = { userName: 'value',fullName:''};
  Activite: any = [];
  Priorite: any = [];
  SelectedParticipant: any = [];
  ngOnInit() {
   // this.notification.getAllUsersTrue();
    this.formation.GetAllParticipant();
    this.formation.getAllFormation();
    this.formation.GetAllBesoinCollecte();
    this.resetForm();
    this.formation.formModel.reset();
    this.formation.formModele.reset();
   

    this.Activite = [
      { "key": "Meltumedia", "value": "Meltumedia" },
      { "key": "Inteligence", "value": "Inteligence" },
      { "key": "artificielle", "value": "artificielle" },
      { "key": "Electronique", "value": "Electronique" },
      { "key": "Qualité", "value": "Qualité" },
      { "key": "Mecanique", "value": "Mecanique" }

    ];

    this.Priorite = [
      { "key": "1", "value": "1" },
      { "key": "2", "value": "2" },
      { "key": "3", "value": "3" }
    ];

  }
  resetForm(form?: NgForm) {
    if (form != null)
       form.form.reset();
     this.formation.formData1 = {
       id:'',
       nom:'',
      prenom:'',
     
     }
   }
   ParticipantChange(event) {
    let index = this.SelectedParticipant.indexOf(event.target.value);
    console.log(index);
    if (index == -1) {
      this.SelectedParticipant.push(event.target.value);
    } else {
      this.SelectedParticipant.splice(index, 1);
    }
    console.log(this.SelectedParticipant);
  }
   onSubmitParticipant(){
    console.log();
    console.log(this.SelectedParticipant);
    for (var val of this.SelectedParticipant) {
    this.formation.registerParticipant(val).subscribe(
      (res: any) => {
        if (res.succeeded) {
  // // this.formation.formModele.reset();
     this.toastr.success('New user created!','Registration successful.');
  //   // this.formation.refreshList();

      } 
    },

   );}
   this.formation.formModele.reset();
   }


  onSubmit() {
    console.log();
    this.formation.registerFormation().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.toastr.success('New user created!', 'Registration successful.');
        }
      },

    );
    this.formation.formModel.reset();
  }

  

  OnRegisterParticipant() {
    //console.log(item);
    console.log(this.SelectedParticipant);
    console.log(this.formation.formModel.value.intitule_formation);
    for (var val of this.SelectedParticipant) {
      console.log(val);
      this.formation.PostRegisterParticipant(val).subscribe(
        (res: any) => {
          if (res.succeeded) {
            debugger;
            this.resetForm();
            this.toastr.success('Submitted successfully', 'User Accepted');
            console.log("ok");
            this.formation.refreshList();
          }
          else { this.toastr.success('Erreur', 'Erreur update'); }
        });
    }

  }
  RegisterNewParticipant(){
    this.formation.postNewParticipant().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.toastr.success('New user created!', 'Registration successful.');
         
        }
      },

    );
    this.formation.refreshList();
    this.formation.ParticipantModel.reset();
    
  }

  
}
