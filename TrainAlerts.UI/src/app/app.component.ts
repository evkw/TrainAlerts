import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Reader } from "protobufjs";

import 'rxjs/add/operator/map';

var Pbf = require('pbf');

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  info;

  constructor(private http: Http) { }

  ngOnInit() {
    this.http.get("http://localhost:5000/api/values")
      .map(res => {
        this.info = new Pbf(new Uint8Array(res.arrayBuffer()));
        //String.fromCharCode.apply(null, new Uint8Array(res.arrayBuffer()));
        //this.info = Reader.create(new Uint8Array(res.arrayBuffer()));
        console.log(this.info);
      }).toPromise();
  }

}
