import { Component, OnInit } from '@angular/core';
import { RestService } from '../restapi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-relational-view',
  templateUrl: './relational-view.component.html',
  styleUrls: ['./relational-view.component.css']
})
export class RelationalViewComponent implements OnInit {

   schemasData:any = [];

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.getBlocks();
    }

    getBlocks() {
        this.schemasData = [];
        this.rest.getSchemas().subscribe((data: {}) => {
          console.log(data);
          this.schemasData = data;
    });
  }
    
    backToHome() {
        this.router.navigate(['/']);
    } 

}