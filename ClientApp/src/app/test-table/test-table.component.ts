import { Component, OnInit,OnDestroy, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Customer } from '../models/customer';

@Component({
  selector: 'app-test-table',
  templateUrl: './test-table.component.html',
  styleUrls: ['./test-table.component.css']
})
export class TestTableComponent implements OnDestroy, OnInit {

  dtOptions: DataTables.Settings = {};
  data: Customer[] = [];

 
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private httpClient: HttpClient,  @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {

      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 2,
        processing: true,
    };

    this.httpClient.get<Customer[]>(this.baseUrl + 'customers').subscribe(result => {
        this.data = result;
        console.log(this.data)
        this.dtTrigger.next();
      }, error => console.log(error)); 
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

}
// interface Customer {
//   customerId : number;
//   customerName:  string;
//   paymentDays : number;
//   phoneNumber : string;
//   faxNumber : string; 
// }
