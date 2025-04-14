const util = {
    isNullOrEmpty: (src: string | null | undefined) => {
        return src == null || src === '';
    },
};

export default util;