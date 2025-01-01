// Convert all fields to camelCase/PascalCase

struct wimlib_object_id {
	uint8_t object_id[WIMLIB_GUID_LEN];
	uint8_t birth_volume_id[WIMLIB_GUID_LEN];
	uint8_t birth_object_id[WIMLIB_GUID_LEN];
	uint8_t domain_id[WIMLIB_GUID_LEN];
};
