import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskqueryComponent } from './taskquery.component';

describe('TaskqueryComponent', () => {
  let component: TaskqueryComponent;
  let fixture: ComponentFixture<TaskqueryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskqueryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskqueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
