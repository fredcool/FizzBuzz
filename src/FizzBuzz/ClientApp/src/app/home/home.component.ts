import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { faSpinner, faWindowMinimize } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [':host { width: 100%; }',
    '.blink { animation: blinking 600ms infinite;}',
    `@keyframes blinking {
  0% {
    color: #000;
  }
  100% {
    color: #fff;
  }
}`
  ]
})
export class HomeComponent {
  public lines: string[] = [];
  public isLoading: boolean = false;
  public fizzBuzzForm: FormGroup;
  private baseUrl: string;
  private httpClient: HttpClient;
  private formBuilder: FormBuilder;
  faSpinner = faSpinner;
  faWindowMinimize = faWindowMinimize;

  constructor(httpClient: HttpClient, formBuilder: FormBuilder, @Inject('BASE_URL') baseUrl: string) {
    this.formBuilder = formBuilder;
    this.baseUrl = baseUrl;
    this.httpClient = httpClient;
    this.fizzBuzzForm = formBuilder.group({
      maxNumber: formBuilder.control(100),
      divisors: formBuilder.array([formBuilder.group({
        divisor: 3,
        printedWord: 'Fizz'
      }), formBuilder.group({
        divisor: 5,
        printedWord: 'Buzz'
      })])
    });
  }

  get divisors() {
    return this.fizzBuzzForm.get('divisors') as FormArray;
  }

  addDivisor() {
    this.divisors.push(this.formBuilder.group({
      divisor: null,
      printedWord: null
    }));
  }

  deleteDivior(index: number) {
    this.divisors.removeAt(index);
  }

  onSubmit(): void {
    this.lines = [];
    this.isLoading = true;
    this.httpClient.post<{ lines: string[] }>(this.baseUrl + 'fizzbuzz', {
      ...this.fizzBuzzForm.value
    }).subscribe(result => {
      this.isLoading = false;
      this.lines = result.lines;
    }, error => console.error(error)
      , () => {
        this.isLoading = false;
    });
  }
}
