import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  public categoryId: string;

  onChangeCategory(categoryId: string) {
    this.categoryId = categoryId;
  }
  
}