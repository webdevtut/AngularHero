import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
// import { HeroService } from '../hero.service';
// import { MessageService } from '../message.service';
import { HttpClient,HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.scss']
})

export class HeroesComponent implements OnInit {

  heroes: any ;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  // private heroService: HeroService, private messageService: MessageService,

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes(){
    this.http.get('https://localhost:5001/api/heroes').subscribe(response => {
      this.heroes = response;
      console.log(response);
      
    }, error => {
      console.log(error);
      
    })
  }
  addHero(name: string) : void{
    name = name.trim(); 
    let Obj= {
      heroName : name
    }
    this.http.post('https://localhost:5001/api/heroes/add', Obj,this.httpOptions).subscribe(response => {
      this.heroes.push(response)
      
    }, error => {
      console.log(error);
      
    })
  }

  // getHeroes(): void {
  //   this.heroService.getHeroes()
  //       .subscribe(heroes => this.heroes = heroes);
  // }

  // add(name: string): void {
  //   name = name.trim();
  //   if (!name) { return; }
  //   this.heroService.addHero({ name } as Hero)
  //     .subscribe(hero => {
  //       this.heroes.push(hero);
  //     });
  // }
  // delete(hero: Hero): void {
  //   this.heroes = this.heroes.filter(h => h !== hero);
  //   this.heroService.deleteHero(hero.id).subscribe();
  // }
}