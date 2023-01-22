export async function share(shareData) {
    try {
        await navigator.share(shareData)
        return {
            isSuccess: true
        };
    }
    catch (error) {
        return {
            errorMessage: error.message,
            errorname: error.name,
            isSuccess: false
        };
    }
}

export function isSupported() {
    if (navigator.share)
        return true;
    return false;
}