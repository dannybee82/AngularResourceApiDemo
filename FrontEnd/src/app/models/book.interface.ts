import { Author } from "./author.interface";
import { Publisher } from "./publisher.interface";

export interface Book {
	id?: number,
	title: string,
	description: string,
	isbn: string,
	author?: Author,
	publisher?: Publisher,
	dateCreated: string
}