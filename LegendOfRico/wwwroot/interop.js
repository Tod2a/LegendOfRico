window.saveFile = async (jsonData) => {
    try {
        await DotNet.invokeMethodAsync('LegendOfRico', 'SaveFile', jsonData);
    } catch (error) {
        console.error('Error invoking SaveFile:', error);
    }
};