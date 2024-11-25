export class ReformatDates {

    formatDateToString(date: string, reverse: boolean): string {
        if(date) {
            const replaceData: RegExp = /(t|T).*$/g;
            let parts: string[] = date.replace(replaceData, '').split("-");

            if(reverse) {
                parts.reverse();
            }

            let d: Date = new Date();

            let day: number = parseInt(parts[0]);
            let month: number = parseInt(parts[1]);
            
            if(reverse) {
                day = day + 1;                
            }

            month = month - 1;

            d.setDate(day);
            d.setMonth(month);
            d.setFullYear(parseInt(parts[2]));

            return d.toJSON();
        }

        return "";
    }

    reformatDateForForms(date: string, reverse: boolean): string {
        const cleanUp: RegExp = /(t|T|\s).*$/g;
        date = date.replace(cleanUp, '');

        let parts: string[] = date.split('-');

        if(reverse) {
            parts.reverse();
        }

        return `${parts[0]}-${parts[1]}-${parts[2]}`;
    }

}