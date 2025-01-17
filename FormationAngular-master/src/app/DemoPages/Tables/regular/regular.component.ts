import {Component, OnInit} from '@angular/core';
import { CompetenceService } from '../../shared/competence.service';
import { AngularFontAwesomeComponent } from 'angular-font-awesome';

interface Country {
  name: string;
  flag: string;
  area: number;
  population: number;
}

const COUNTRIES: Country[] = [
  {
    name: 'Russia',
    flag: 'f/f3/Flag_of_Russia.svg',
    area: 17075200,
    population: 146989754
  },
  {
    name: 'Canada',
    flag: 'c/cf/Flag_of_Canada.svg',
    area: 9976140,
    population: 36624199
  },
  {
    name: 'United States',
    flag: 'a/a4/Flag_of_the_United_States.svg',
    area: 9629091,
    population: 324459463
  },
  {
    name: 'China',
    flag: 'f/fa/Flag_of_the_People%27s_Republic_of_China.svg',
    area: 9596960,
    population: 1409517397
  }
];

@Component({
  selector: 'app-regular',
  templateUrl: './regular.component.html',
  //templateUrl: 
  styles: []
})
export class RegularComponent implements OnInit {

  heading = 'Regular Tables';
  subheading = 'Tables are the backbone of almost all web applications.';
  icon = 'pe-7s-drawer icon-gradient bg-happy-itmeo';

  constructor(public competence: CompetenceService) {
  }

  countries = COUNTRIES;

  ngOnInit() {
    this.competence.getAllUsersTrue();
    this.competence.GetAllLabels();
    console.clear()
  }

  getUserLabelSum(user,label){
    let sum = 0
    if (user && user.occ ) {
      let userLabObj = user.occ[label.nomLabel]
      console.log("*********** userLabObj: ",userLabObj)
      if (userLabObj) {
        sum = userLabObj.sum
      }
      console.log("*********** sum: ",sum)
      
    }

    return sum
  }

  getItems( id) {
    return this.competence.LabeList.filter((item) =>
     item.domaineId === id);
  }
  isShow = false;



 
  toggleDisplay() {
    this.isShow = !this.isShow;
  }
  
}
