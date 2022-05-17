import { Component, OnInit, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-add-like',
  templateUrl: './add-like.component.html',
  styleUrls: ['./add-like.component.css']
})
export class AddLikeComponent implements OnInit {
  @Output() onSubmitLike:EventEmitter<any>=new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }
  submitLike(){
    this.onSubmitLike.emit()
  }

}
