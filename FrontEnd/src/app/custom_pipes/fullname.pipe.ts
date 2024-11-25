import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'fullname',
    pure: true
})
export class FullnamePipe implements PipeTransform {

    transform(obj: object | null | undefined) : string {
        if(obj) {
            let keys: string[] = Object.keys(obj);
            let values: string[] = Object.values(obj);
    
            let fullName: string = "";
    
            let firstNameIndex: number = keys.indexOf('firstName');
            let middleNameIndex: number = keys.indexOf('middleName');
            let lastNameIndex: number = keys.indexOf('lastName');
    
            if(firstNameIndex > -1) {
                fullName += values[firstNameIndex];
            }
    
            if(middleNameIndex > -1) {
                if(values[middleNameIndex].trim() !== '') {
                    fullName += " " + values[middleNameIndex];
                }            
            }
    
            if(lastNameIndex > -1) {
                fullName += " " + values[lastNameIndex];
            }
    
            return fullName;
        }
        
        return "";
    }

}