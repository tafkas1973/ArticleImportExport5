import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'o4u-title',
  templateUrl: './o4u-title.component.html',
  styleUrls: ['./o4u-title.component.css']
})
export class TitleComponent implements OnInit {
  @Input() title: string = "(no title)";

  constructor() { }

  ngOnInit(): void {
  }

}
