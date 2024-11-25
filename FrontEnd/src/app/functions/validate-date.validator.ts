import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export class ValidateDate {

    static validateDate = (): ValidatorFn => {
        return (control: AbstractControl): ValidationErrors | null => {
          try {
            let parts: string[] = control.value.split('-').reverse();
            let dt: Date = new Date(parts.join("-"));
           
            if(dt.toString() === 'Invalid Date') {
                return {"date": {"dateError": true}};
            }

            let json: string = dt.toJSON();
            json = json.substring(0, json.indexOf('T'));
            let joined: string = parts.join("-");

            if(json !== joined) {
              return {"date": {"dateError": true}};
            }

            return null;
          } catch {
            return {"date": {"dateError": true}};
          }
        }
      };

}