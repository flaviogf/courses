export function changeValue(e) {
    return {
        type: 'CHANGE_VALUE',
        payload: e.target.value
    }
}