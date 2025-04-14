/* eslint-disable @typescript-eslint/no-explicit-any */
const ls = {
    load: <T>(key: string) => {
        try {
            const valSerialized = localStorage.getItem(key);
            if (valSerialized === null) {
                return undefined;
            }
            return JSON.parse(valSerialized) as T;
        } catch {
            return undefined;
        }
    },

    set: (key: string, value: any) => {
        try {
            const serializedValue = JSON.stringify(value);
            localStorage.setItem(key, serializedValue);
        } catch {
            // ignore write errors
        }
    },

    clear: () => {
        localStorage.clear();
    }
}

export default ls;