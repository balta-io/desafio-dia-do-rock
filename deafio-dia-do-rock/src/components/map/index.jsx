import React from "react";
import {GoogleMap, useJsApiLoader, Marker, InfoWindow} from '@react-google-maps/api';
import moment from "moment";
import 'moment/locale/pt-br'

const containerStyle = {
    width: '100%',
    height: '100vh'
};

function Map({center, zoom, markers = [], panTo = null}) {
    const [selectedElement, setSelectedElement] = React.useState(null);
    const [activeMarker, setActiveMarker] = React.useState(null);
    const [showInfoWindow, setInfoWindowFlag] = React.useState(true);

    const { isLoaded } = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: process.env.REACT_APP_GOOGLE_MAPS_API_KEY
    })

    const [map, setMap] = React.useState(null)

    const onLoad = React.useCallback(function callback(map) {
        // This is just an example of getting and using the map instance!!! don't just blindly copy!
        map.setZoom(zoom)

        setMap(map)
    }, [])

    React.useEffect(() => {
        if(map && panTo) {
            map.panTo(panTo)
        }
    }, [panTo])

    const onUnmount = React.useCallback(function callback(map) {
        setMap(null)
    }, [])

    const defaultMapOptions = {
        disableDefaultUI: true,
        zoomControl: true,
    }

    return isLoaded ? (
        <GoogleMap
            mapContainerStyle={containerStyle}
            center={center}
            zoom={zoom}
            options={defaultMapOptions}
            onLoad={onLoad}
            onUnmount={onUnmount}
        >
            {markers.map(item => (
                <Marker
                        key={item.id}
                        title={item.title}
                        position={item.position}
                        onClick={(props, marker) => {
                            setSelectedElement(item);
                            setActiveMarker(marker);
                        }}/>))}
            {selectedElement ? (
                <InfoWindow
                    visible={showInfoWindow}
                    marker={activeMarker}
                    position={selectedElement.position}
                    onCloseClick={() => {
                        setSelectedElement(null);
                    }}
                >
                    <div className="flex flex-col w-52 gap-2">
                        <h1 className="font-black text-lg">{selectedElement.title}</h1>
                        <p>{selectedElement.description}</p>

                        <div className="flex flex-col gap-1 mt-2 font-bold rounded">
                        <p className="">{selectedElement.address}</p>
                        <p className="">{moment(selectedElement.datetime).locale('pt-br').format('LLLL')}</p>
                        </div>
                    </div>
                </InfoWindow>
            ) : null}
            <></>
        </GoogleMap>

    ) : <></>
}

export default React.memo(Map)
