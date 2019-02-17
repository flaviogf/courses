export interface ServiceInterface<T> {
    findAll(): Promise<T[]>;
    find(id: number): Promise<T>;
    create(objeto: T): Promise<T>;
    update(objeto: T): Promise<T>;
    deletar(objeto: T): Promise<T>;
}
