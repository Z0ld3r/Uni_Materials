#!/bin/bash

wget -t 100 \
	"https://gea.esac.esa.int/tap-server/tap/sync?REQUEST=doQuery&LANG=ADQL&FORMAT=csv&QUERY=SELECT+TOP+2000000+\
		ra,dec,phot_g_mean_mag,phot_g_mean_flux,phot_g_mean_flux_error,ref_epoch,pmra,pmdec,parallax,radial_velocity+\
		FROM+gaiadr3.gaia_source+\
		WHERE+CONTAINS(POINT('ICRS',gaiadr3.gaia_source.ra,gaiadr3.gaia_source.dec),CIRCLE('ICRS',56.5759064,24.1414785,1.5))=1" \
	 -O M45.csv
